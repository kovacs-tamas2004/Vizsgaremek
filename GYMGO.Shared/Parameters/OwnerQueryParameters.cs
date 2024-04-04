﻿namespace GYMGO.Shared.Parameters
{
    public class OwnerQueryParameters
    {
        public uint MinYearOfBirth { get; set; }
        public uint MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;
        public string Name { get; set; } = string.Empty;

        public bool ValidYearRange => MaxYearOfBirth > MinYearOfBirth;
    }
}
