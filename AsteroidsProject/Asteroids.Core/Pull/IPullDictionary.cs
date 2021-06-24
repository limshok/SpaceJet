
namespace Asteroids.Core.Pull
{
    public interface IPullDictionary<TIndex, TPull>
    {
        TPull GetPull(TIndex index);
    }


    public interface IPullDictionary<TIndexA, TIndexB, TPull>
    {
        TPull GetPull(TIndexA indexA, TIndexB indexB);
    }
}