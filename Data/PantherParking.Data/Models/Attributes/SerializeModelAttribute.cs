using System;

namespace PantherParking.Data.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SerializeModelAttribute : Attribute
    {
         
    }
}