﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_3;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private int[] _penaltytimes;

            //свойства
            public string Name => _name; //?? "Unknown";
            public string Surname => _surname; // ?? "Unknown";
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltytimes == null)
                    {
                        return null;
                    }

                    int[] newArr = new int[_penaltytimes.Length];
                    Array.Copy(_penaltytimes, newArr, _penaltytimes.Length);
                    return newArr;
                }
            }
            public int TotalTime
            {
                get
                {
                    if (_penaltytimes == null || _penaltytimes.Length == 0)
                    {
                        return 0;
                    }
                    int sum = 0;
                    for (int i = 0; i < _penaltytimes.Length; i++)
                    {
                        sum += _penaltytimes[i];
                    }
                    return sum;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_penaltytimes == null)
                    {
                        return true;
                    }
                    for (int i = 0; i < _penaltytimes.Length; i++)
                    {
                        if (_penaltytimes[i] == 10)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            //конструкторы
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltytimes = new int[0];
            }

            //методы
            public void PlayMatch(int time)
            {
                if (_penaltytimes == null)
                {
                    return;
                }
                Array.Resize(ref _penaltytimes, _penaltytimes.Length + 1);
                _penaltytimes[_penaltytimes.Length - 1] = time;
            }
            public static void Sort(Participant[] participants)
            {
                if (participants == null) {
                    return;
                }

                for (int i = 0; i < participants.Length; i++)
                {
                    for (int j = 0; j < participants.Length - i - 1; j++)
                    {
                        if (participants[j + 1].TotalTime < participants[j].TotalTime)
                        {
                            (participants[j], participants[j + 1]) = (participants[j + 1], participants[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {TotalTime} {IsExpelled}");
            }
        }
    }
}
