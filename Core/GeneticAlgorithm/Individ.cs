using Core.Neural;


namespace Core.Genetics;

public class Individ
{
    public NeuralNetwork Network {get;}
    public double Fitness {get; private set;}

    public void SetFitness(double fitness) => Fitness = fitness;


    public Individ(int[] layers)
    {
        Network = new NeuralNetwork(layers);
        Fitness = 0;
    }
}