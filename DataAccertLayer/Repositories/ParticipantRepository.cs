using DataAccessLayer.Model;
using DataAccessLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class ParticipantRepository : IRepository<Participant>
    {
        private readonly AppDbContext _context;

        public ParticipantRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Participant> GetAll()
        {
            return _context.Participants.ToList();
        }

        public Participant GetById(int id)
        {
            return _context.Participants.Find(id);
        }

        public void Add(Participant participant)
        {
            _context.Participants.Add(participant);
            _context.SaveChanges();
        }

        public void Update(Participant participant)
        {
            _context.Participants.Update(participant);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var participant = _context.Participants.Find(id);
            if (participant != null)
            {
                _context.Participants.Remove(participant);
                _context.SaveChanges();
            }
        }
    }
}