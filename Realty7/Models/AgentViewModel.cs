using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Realty7Model;
using PagedList;

namespace Realty7.Models
{
    public class AgentViewModel
    {
        //public List<agent> Agents { get; set; }
        Realty7Entities context;
        UnitOfWork unitOfWork;
        const int itemsPerPage = 50;

        public IPagedList<agent> Agents { get; set; }

        public string Sort { get; set; }

        public void GetAgents(int? _page, string _sort)
        {
            unitOfWork = new UnitOfWork();
            var page = _page ?? 1;
            var sort = _sort ?? "d";
            IPagedList<agent> agents;
            
            switch (sort)
            {
                case "d":
                    agents = unitOfWork.AgentRepository.Get().OrderBy(a => a.Priority).ToPagedList(page, itemsPerPage);
                    break;
                case "f":
                    agents = unitOfWork.AgentRepository.Get().OrderBy(a => a.FirstName).ToPagedList(page, itemsPerPage);
                    break;
                case "l":
                    agents = unitOfWork.AgentRepository.Get().OrderBy(a => a.LastName).ToPagedList(page, itemsPerPage);
                    break;
                default:
                    agents = unitOfWork.AgentRepository.Get().OrderBy(a => a.Priority).ToPagedList(page, itemsPerPage);
                    break;
            }
            Sort = sort;
            Agents = agents;
        }

    }
}