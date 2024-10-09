using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api")]
[ApiController]
public class RootController : ControllerBase
{
	private readonly LinkGenerator _linkGenerator;

	public RootController(LinkGenerator linkGenerator) => _linkGenerator = linkGenerator;

	[HttpGet(Name = "GetRoot")]
	public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
	{
		if (mediaType.Contains("application/vnd.kingsman.apiroot"))
		{
			var list = new List<Link>
				{
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new {}),
						Rel = "self",
						Method = "GET"
					},
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext, "GetProducts", new {}),
						Rel = "products",
						Method = "GET"
					},
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, "CreateProduct", new {}),
                        Rel = "create_product",
                        Method = "POST"
                    },
                    new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext, "GetOrders", new {}),
						Rel = "orders",
						Method = "POST"
					}
				};

			return Ok(list);
		}

		return NoContent();
	}
}
