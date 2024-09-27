//Public Domain

using HomeKitDotNet.Crypto.Internal;

namespace HomeKitDotNet.Crypto.Internal
{
    internal static partial class FieldOperations
	{
		public static void fe_1(out FieldElement h)
		{
			h = default(FieldElement);
			h.x0 = 1;
		}
	}
}