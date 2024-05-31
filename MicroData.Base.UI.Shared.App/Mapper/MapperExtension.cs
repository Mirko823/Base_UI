using System.ComponentModel;
using System.Reflection;

namespace MicroData.Base.UI.Shared.App.Mapper
{
    public static class MapperExtension
    {
        private static string GetDescriptionAttribute(Type type, string member)
        {

            MemberInfo[] memInfo = type.GetMember(member);
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return member;
        }
    }
}
