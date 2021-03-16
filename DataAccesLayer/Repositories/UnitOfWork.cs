using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;

        IAdRepository IUnitOfWork.AdRepository => throw new NotImplementedException();

        ICommentRepository IUnitOfWork.CommentRepository => throw new NotImplementedException();

        IFavoriteRepository IUnitOfWork.FavoriteRepository => throw new NotImplementedException();

        IForCompareRepository IUnitOfWork.ForCompareRepository => throw new NotImplementedException();

        IImageRepository IUnitOfWork.ImageRepository => throw new NotImplementedException();

        ITagRepository IUnitOfWork.TagRepository => throw new NotImplementedException();

        IUserRepository IUnitOfWork.UserRepository => throw new NotImplementedException();

        Task IUnitOfWork.SaveAsync()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
