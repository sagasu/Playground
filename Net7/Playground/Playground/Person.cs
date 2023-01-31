using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground;
public class PersonOld
{
    public PersonOld(string fullName)
    {
        FullName = fullName;
    }

    public Guid ID { get; set; } = Guid.NewGuid();
    public string FullName { get; set; }
}


public class Person
{
    public Guid ID { get; set; } = Guid.NewGuid();
    public required string FullName { get; set; }
}

