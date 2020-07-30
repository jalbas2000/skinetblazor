using System.Threading.Tasks;

namespace web.Services
{
    public interface IErrorService
    {
         Task Get404Error();
         Task Get500Error();
         Task Get400Error();
         Task Get400ValidationError();
    }
}