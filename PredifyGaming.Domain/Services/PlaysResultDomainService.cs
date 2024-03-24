using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Domain.Interfaces.Services;


namespace PredifyGaming.Domain.Services
{
    public class PlaysResultDomainService : BaseDomainService<PlaysResult> , IPlaysResultDomainService
    {
        private readonly IUnitOfWork<PlaysResult> _unitOfWork;

        public PlaysResultDomainService(IUnitOfWork<PlaysResult> unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PlaysResult>> GetAllByGameAsync(long idGame)
        {
            return await _unitOfWork.PlaysResultRepository.GetAllByGameAsync(idGame);
        }

        public async Task<List<PlaysResult>> GetAllByPlayerAsync(long idPlayer)
        {
            return await _unitOfWork.PlaysResultRepository.GetAllByPlayerAsync(idPlayer);
        }

        public override async Task<PlaysResult> CreateAsync(PlaysResult entity)
        {
            try
            {
               await _unitOfWork.BeginTransactionAsync();

                    var playerById = await _unitOfWork.PlayersRepository.GetByIdAsync(entity.PlayerId);
                    var gameById = await _unitOfWork.GamesRepository.GetByIdAsync(entity.GameId);
                    long pointsGenerator = (long)new Random().Next(-15, 21);

                    if (playerById is null)
                        throw new Exception($@"ID Player {entity.PlayerId} não encontrado.");

                    if (gameById is null)
                        throw new Exception($@"ID {entity.GameId} não pertence a um Game");

                    entity.PointsResult = pointsGenerator;
                    var data = await _unitOfWork.PlaysResultRepository.CreateAsync(entity);

                await _unitOfWork.CommitAsync();
                return data;


            } catch (Exception)
            {
                await _unitOfWork.RollBackAsync();
                throw;
            }
            
        }

        public async Task<List<PlaysResult>> GetByPlayerIsGameAsync(long idPlayer, long idGame)
        {
            return await _unitOfWork.PlaysResultRepository.GetByPlayerIsGameAsync(idPlayer, idGame);
        }
    }
}
