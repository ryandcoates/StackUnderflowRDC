using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StackUnderflowRDC.Entities.DTO
{
	public class QuestionDto
	{
		public Question Question { get; set; }
		public List<ResponseDto> Responses { get; set; }
	}

	public class ResponseDto
	{
		public Response Response { get; set; }
		public List<Comment> Comments { get; set; }
	}
}