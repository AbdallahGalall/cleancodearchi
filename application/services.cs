using cleancodearchi.domain;
using cleancodearchi.infrastructure;
using Microsoft.EntityFrameworkCore;

namespace cleancodearchi.application
{
    public class services : Interface
    {
       private readonly Appdbcontext _dbcon;

       public services(Appdbcontext dbcon)
        {
           _dbcon = dbcon;
        }

        public  List<model> getall()
        {
            var res = _dbcon.tasks.ToList();
            return res;
        }
        public  model? getbyid(int id)
        {
            var t_id = _dbcon.tasks.Find(id);
            if (t_id == null) {return null;}
            return t_id;
        }

        public async Task<model?> creattask(model new_task)
        {
            await _dbcon.tasks.AddAsync(new_task);
            int changecount=await _dbcon.SaveChangesAsync();
            return new_task;
        }
        public  async Task<model?> updatetask(model task, int id)
        {
            var t_id= _dbcon.tasks.Find(id);
            if (t_id is null) { return null; }

            t_id.task_desc = task.task_desc;
            t_id.status = task.status;           
         
            _dbcon.tasks.Update(t_id);
            await _dbcon.SaveChangesAsync();
            return t_id;
        }
        public  async Task<int> deletetask(int id)
        {
            var t_id = _dbcon.tasks.Find(id);
            if (t_id is null)
            {
                return 0; 
            }
            _dbcon.tasks.Remove(t_id);
            var removechange=await _dbcon.SaveChangesAsync();
            return removechange;


        }

    }
}
