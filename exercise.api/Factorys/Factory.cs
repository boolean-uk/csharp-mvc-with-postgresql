namespace exercise.api.Factorys
{
    public abstract class Factory<TModel, TInputDTO, TOutputDTO> : IFactory<TModel, TInputDTO, TOutputDTO>
    {
        public abstract TModel FromDTO(TInputDTO dto);
        public abstract TOutputDTO ToDTO(TModel model);
        public abstract void UpdateFromDTO(TModel existingModel, TInputDTO dto);
    }
}