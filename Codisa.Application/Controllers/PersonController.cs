using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HugoApp.Application.Models.Person;
using HugoApp.Core.Entities;
using HugoApp.Infrastructure.ParamsDTO;
using HugoApp.Infrastructure.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Mvc;

namespace HugoApp.Application.Controllers
{
    public class PersonController : Controller
    {
        #region ATTRIBUTES
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public PersonController(IMapper mapper, IPersonRepository personRepository)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region "METODOS"
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IList<PersonDto>>(await _personRepository.GetAllPerson()));
        }

        [HttpGet]
        public IActionResult NewPerson()
        {
            var model = new CreatePerson { };
            return View("NewPerson", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SavePerson(CreatePerson createPerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _personRepository.CreatePerson(_mapper.Map<Person>(createPerson));
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception)
            {
                return BadRequest();
            }

            return View("NewPerson", createPerson);
        }

        [HttpGet]
        public IActionResult EditPerson(UpdatePerson updatePerson)
        {
            return View("EditPerson", updatePerson);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SaveUpdatePerson(UpdatePerson updatePerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _personRepository.UpdatePerson(_mapper.Map<Person>(updatePerson));
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception)
            {
                return BadRequest();
            }

            return View("EditPerson", updatePerson);
        }

        [HttpGet]
        public ActionResult DeletePerson(int id)
        {
            try
            {
                _personRepository.DeletePerson(id);
            } catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}