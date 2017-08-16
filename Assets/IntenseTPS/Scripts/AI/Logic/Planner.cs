using Actions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Used to calculate an estimated valid plan, called by <see cref="AIBrain"/>
/// </summary>
public class Planner
{
    private List<AIAction> minCostPlan = new List<AIAction>();

    //private int letter = 0;
    private Dictionary<AIGoal, List<AIAction>> goalsToRelatedActions;

    public Planner(List<AIAction> _actions, List<AIGoal> _goals)
    {
        goalsToRelatedActions = new Dictionary<AIGoal, List<AIAction>>();
        foreach (var goal in _goals)
            goalsToRelatedActions.Add(goal, GetRelated(goal.goalStates, new List<AIAction>(), _actions));
    }

    public Queue<AIAction> CalculatePlan(AIBrain ai, List<AIAction> allActions, StateDictionary currentWorldState, List<AIGoal> allGoals, out AIGoal activeGoal)
    {
        List<AIAction> applicapableActions = new List<AIAction>();
        foreach (AIAction action in allActions)
        {
            if (action.CanBeAddedToPlan(ai)) // to remove unnecessary action branch in tree
            {
                action.JustBeforePlan(ai);
                action.CalculateCost(ai); // Some actions can use dynamic cost based on confidence factors
                applicapableActions.Add(action);
            }
        }

        applicapableActions = applicapableActions.OrderBy(x => x.Cost).ToList();

        List<Node> goalMatchingNodes = new List<Node>();
        foreach (AIGoal goal in allGoals)
        {
            if (!goal.IsApplicapable(ai))
            {
                goal.Applicapable = false;
                continue;
            }
            goal.Applicapable = true;

            minCostPlan = new List<AIAction>();

            //letter = 0;
            Node startNode = new Node(/*letter++ + ""*/);
            StateDictionary cWorldState = new StateDictionary(currentWorldState.conditions);

            // Creates paths including first lowest cost action path
            float maxCSoFar = Mathf.Infinity;

            List<AIAction> applicapableNRelatedActions = new List<AIAction>();
            foreach (var action in applicapableActions)
            {
                if (goalsToRelatedActions[goal].Contains(action))
                    applicapableNRelatedActions.Add(action);
            }

            CreateActionTree(startNode, cWorldState, goal.goalStates, applicapableNRelatedActions /*applicapableActions*/, goalMatchingNodes, ref maxCSoFar);
            if (minCostPlan.Count > 0)
            {
                Queue<AIAction> actionQ = new Queue<AIAction>();
                foreach (AIAction action in minCostPlan)
                {
                    actionQ.Enqueue(action);
                }
                activeGoal = goal;
                goal.lastUsedAt = Time.time;
                return actionQ;
            }
            else
                continue;
        }
        activeGoal = null;
        return null;
    }

    private List<AIAction> GetRelated(StateDictionary sd, List<AIAction> relatedActionsSoFar, List<AIAction> allActions)
    {
        foreach (var kvp in sd.conditions)
        {
            foreach (var action in allActions)
            {
                foreach (var kvpPost in action.postEffects.conditions)
                {
                    if (kvpPost.Key == kvp.Key && kvpPost.Value.ToString() == kvp.Value.ToString())
                        if (!relatedActionsSoFar.Contains(action))
                        {
                            relatedActionsSoFar.Add(action);
                            GetRelated(action.preConditions, relatedActionsSoFar, allActions);
                        }
                }
            }
        }
        return relatedActionsSoFar;
    }

    private void CreateActionTree(Node root, StateDictionary cWorldState, StateDictionary goalState, List<AIAction> allActions, List<Node> matchNodes, ref float minCostPlanSoFar)
    {
        foreach (AIAction action in allActions)
        {
            if (root.cost + action.Cost < minCostPlanSoFar && action.CanApplyToWorld(cWorldState))
            {
                StateDictionary newWorldState = new StateDictionary(cWorldState.conditions);
                StateDictionary.OverrideCombine(action.postEffects, newWorldState);
                Node newNode = new Node(/*letter++ + "",*/ root.cost + action.Cost, root, action);

                // check to see if goal is satisfied
                if (StateDictionary.ConditionsMatch(goalState, newWorldState))
                {
                    matchNodes.Add(newNode);
                    minCostPlanSoFar = newNode.cost;

                    minCostPlan.Clear();
                    Node tempNode = newNode;
                    while (tempNode.parent != null)
                    {
                        minCostPlan.Insert(0, tempNode.upperAction);
                        tempNode = tempNode.parent;
                    }

                    continue;
                }
                else
                {
                    List<AIAction> newActionsList = new List<AIAction>(allActions);
                    newActionsList.Remove(action);
                    CreateActionTree(newNode, newWorldState, goalState, newActionsList, matchNodes, ref minCostPlanSoFar);
                }
            }
            else
                continue;
        }
        return;
    }
}