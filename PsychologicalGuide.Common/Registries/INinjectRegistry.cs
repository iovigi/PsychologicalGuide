namespace PsychologicalGuide.Common.Registries
{
    using Ninject;

    public interface INinjectRegistry
    {
        void Register(IKernel kernel);
    }
}
