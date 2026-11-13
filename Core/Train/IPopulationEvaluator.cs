using Core.Genetics;

namespace Core.Training;

public interface IPopulationEvaluator
{
    void EvaluatePopulation(Population population);
}