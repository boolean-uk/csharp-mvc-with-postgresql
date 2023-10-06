namespace exercise.api.Factorys
{
    public interface IFactory<TModel, TInputDTO, TOutputDTO>
    {
        TModel FromDTO(TInputDTO dto);
        TOutputDTO ToDTO(TModel model);
        void UpdateFromDTO(TModel existingModel, TInputDTO dto);
    }
}