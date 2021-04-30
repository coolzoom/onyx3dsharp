
namespace Onyx3D
{
	public class GameAsset
	{
        public bool IsDirty; //means we changed it?

        public bool IsDynamic; //means we are not using asset

        public OnyxProjectAsset LinkedProjectAsset;

        public virtual void Copy(GameAsset other){}
	}
}
