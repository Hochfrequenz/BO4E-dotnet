using System;
using System.Collections.Generic;
using System.Linq;

namespace BO4E.meta
{
    /*** <summary>This class provides a custom attribute used to map EDIFACT enums
     * to their corresponding BO4E representation.</summary>
     * <example>
       <code>
       public enum NetzebeneEdi{
        ...   
        [Mapping(Netzebene.MSP)]
        E05,
        [Mapping(Netzebene.NSP)]
        E06,
        ...
       </code>
     * </example>
     * The classes <see cref="BoEdiMapper"/> and <see cref="EdiBoMapper"/> perform
     * mapping operations Edi&lt;--&gt;BO4E based on this attributes.
     * **/
    internal class MappingAttribute : Attribute
    {
        public MappingAttribute(params object[] enums)
        {
            if (enums.Any(r => r.GetType().BaseType != typeof(Enum))) throw new ArgumentException("enums");

            Mapping = new List<Enum>();
            foreach (Enum e in enums) Mapping.Add(e);
        }

        public List<Enum> Mapping { get; set; }
    }
}