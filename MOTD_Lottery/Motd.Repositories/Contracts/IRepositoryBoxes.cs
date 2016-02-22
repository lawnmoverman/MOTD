using Motd.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motd.Repositories.Contracts
{
    public interface IRepositoryBoxes
    {
        IEnumerable<Box> GetBoxes();

        Box GetBoxes(string lastName);

        void AddPerson(Box newPerson);

        void UpdatePerson(int Id, Box updatedBox);

        void DeletePerson(int Id);

        void UpdatePeople(IEnumerable<Box> updatedBoxes);
    }
}
