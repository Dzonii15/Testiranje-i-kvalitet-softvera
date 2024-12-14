namespace TaskManagement.Model.Abstractions.Validation
{
    public abstract class ValidatableBase : IValidatable
    {
        protected ValidatableBase()
        {
            Validate();
        }

        public abstract void Validate();
    }
}
