﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Crossingover;
using GeneticEngine.Graph;
using GeneticEngine.Mutation;
using GeneticEngine.Selection;

namespace GeneticEngine.Track
{
    public abstract class AbstractTrack : IComparable
    {
        public const int AggregateOfGenotype = -1;
        protected static int Counter;
        private int _item;

        protected AbstractTrack(int[] trackPoints, IGraph graph)
        {
            _item = ++Counter;
            Genotype = new int[trackPoints.Length];
            trackPoints.CopyTo(Genotype, 0);
            _graph = graph;
            TypeOfCrossingover = AbstractCrossingover.WithoutCrossingover;
            TypeOfMutation = AbstractMutation.WithoutMutation;
            TypeOfSelection = AbstractSelection.WithoutSelection;
        }

        protected AbstractTrack(int countOfAllele, IGraph graph, bool autofill)
        {
            _item = ++Counter;
            _graph = graph;
            Genotype = new int[countOfAllele];
            for (int i = 0; i < countOfAllele; i++)
            {
                Genotype[i] = AggregateOfGenotype;
            }
            TypeOfCrossingover = AbstractCrossingover.WithoutCrossingover;
            TypeOfMutation = AbstractMutation.WithoutMutation;
            TypeOfSelection = AbstractSelection.WithoutSelection;

            if (autofill)
            {
                Random randomChromosome = new Random();
                int newRandomChromosome = randomChromosome.Next(countOfAllele - 1);
                for (int i = 0; i < countOfAllele; i++)
                {
                    while (Genotype.Contains(newRandomChromosome))
                    {
                        newRandomChromosome = randomChromosome.Next(countOfAllele);
                    }
                    Genotype[i] = newRandomChromosome;
                }
            }
        }

        public int GetItem()
        {
            return _item;
        }

        public int FirstParent { get; set; }
        public int SecondParent { get; set; }

        protected IGraph _graph;

        public int[] Genotype { get; set; }

        public string TypeOfSelection { get; set; }

        public string TypeOfMutation { get; set; }

        public string TypeOfCrossingover { get; set; }

        public abstract string GetTypeOfTrack();
        public abstract double GetTrackLength();
        public abstract Rib GetWorstRib();
        public abstract Rib GetBestRib();
        public abstract AbstractTrack EmptyClone();
        public abstract AbstractTrack Clone();

        public abstract int CompareTo(object obj);
    }
}
