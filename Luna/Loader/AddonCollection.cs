using System.Collections.Generic;
using System.IO;

namespace Luna.Loader
{

    /// <summary>
    /// An implementation of <see cref="Dictionary{string, Addon}"/> that adds features to make the use of the Chainloader API easier.
    /// </summary>
    public class AddonCollection : Dictionary<string, Addon>
    {
        public static AddonCollection operator +(AddonCollection addons, Addon addon) 
        {
            addons.Add(addon.Path, addon);
            return addons;
        }
    }
}
