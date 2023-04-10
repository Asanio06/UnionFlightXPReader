﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFlightXPReader
{
    public abstract class DataReader
    {
        public Type type { get; }
        public dynamic Value { get; set; }


        protected DataReader(Type type)
        {
            this.type = type;
        }
    }


    public class StringDataReader : DataReader
    {
        public ushort Length { get; set; }

        public StringDataReader(ushort length) : base(typeof(string))
        {
            Length = length;
        }

        public void Update(int index, char character)
        {
            if (index == 0)
            {
                Value = "";
            }

            if (character > 0)
            {
                if (Value.Length <= index)
                    Value = Value.PadRight(index + 1, ' ');

                var current = Value[index];
                if (current != character)
                {
                    Value = Value.Remove(index, 1).Insert(index, character.ToString());
                }
            }
        }
    }

    public class FloatDataReader : DataReader
    {
        public FloatDataReader() : base(typeof(float))
        {
        }
    }

    public class IntDataReader : DataReader
    {
        public IntDataReader() : base(typeof(int))
        {
        }
    }
}