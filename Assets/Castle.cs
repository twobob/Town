﻿namespace Town
{
    public class Castle
    {
        public Patch Patch { get; set; }
        public Wall Wall { get; set; }

        public Castle(Patch patch)
        {
            Patch = patch;
            Patch.HasCastle = true;
        }
    }
}