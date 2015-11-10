using System;

namespace PantherParking.Data.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SerializePropertyAttribute : Attribute
    {
         
    }
}