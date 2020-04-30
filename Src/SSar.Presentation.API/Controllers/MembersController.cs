﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSar.BC.MemberMgmt.Application;
using SSar.BC.MemberMgmt.Application.Commands;
using SSar.BC.MemberMgmt.Application.Queries;

namespace SSar.Presentation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MembersController
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IQueryable<MemberDto>> Get()
        {
            var memberDtos = await _mediator.Send(new GetMembersQuery());
            return memberDtos;
        }

        [HttpGet("{id}")]
        public async Task<MemberDto> Get(int id)
        {
            return await _mediator.Send(new GetMemberByIdQuery() {EntityId = id});
        }

        [HttpPost]
        public async Task<int> Post([FromBody] MemberDto member)
        {
            return await _mediator.Send(new AddMemberCommand(){MemberDto = member});
        }

        [HttpPut]
        public async Task Put([FromBody] MemberDto member)
        {
            await _mediator.Send(new UpdateMemberCommand(){MemberDto = member});
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteMemberCommand(){EntityId = id});
        }
    }
}
