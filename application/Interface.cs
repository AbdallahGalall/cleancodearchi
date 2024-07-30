using cleancodearchi.domain;

namespace cleancodearchi.application
{
    public interface Interface
    {
        public List<model> getall();
        public model? getbyid(int id);
        public  Task<model?> creattask(model new_task);
        public  Task<model?> updatetask(model task, int id);
        public  Task<int> deletetask(int id);

    }
}
