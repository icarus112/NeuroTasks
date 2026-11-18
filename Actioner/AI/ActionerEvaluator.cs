using Core.Training;
using Actioner.Models;
using Core.Genetics;

namespace Actioner.AI;

public class ActionerEvaluator : IPopulationEvaluator
{

    private readonly ActionerObservation observation = new();
    private readonly ActionerConrtoller actionerConrtoller = new();

    public double Calculate(List<Project> selected)
    {
        double fitness = 0;

        foreach(Project project in selected)
        {
            double prob = project.SuccessProbability;
            double profit = project.Profit;
            double cost = project.Cost;

            fitness += prob*profit - (1 - prob) * cost;
        }

        return fitness;
    }

    public void Evaluate(Individ individ, Situation situation)
    {
        double[] inputs = new ActionerObservation().GetState(situation);
        double[] outputs = individ.Network.Forward(inputs);
        List<Project> selected = new ActionerConrtoller().SelectProjects(situation, outputs);
        
        double fitness = Calculate(selected);
        individ.SetFitness(fitness);
    }

    public void EvaluatePopulation(Population population)
    {
        
    }
}