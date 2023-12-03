using System;
using System.Collections.Generic;

namespace GOD_Assistant;

public partial class Operator
{
    public int Id { get; set; }

    public string? SourseName { get; set; }

    public string? RuName { get; set; }

    public int ClassId { get; set; }
    public Operator()
    {

    }
    public Operator(int operId, string sourseName, string ruName = null)
    {
        Id = operId;
        SourseName = sourseName;
        RuName = ruName;
    }
}
