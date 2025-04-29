using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAllProducts
{
    // Query to get all products with pagination
    // this class is responsible for defining the input parameters for the query
    public class GetAllProductsQuery : IRequest<PagedResponse<IEnumerable<GetAllProductsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedResponse<IEnumerable<GetAllProductsViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllProductsViewModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var parametres = _mapper.Map<GetAllProductsParameter>(request);
            var products = await _productRepository.GetPagedReponseAsync(parametres.PageNumber,parametres.PageSize);
            var productViewModels = _mapper.Map<IEnumerable<GetAllProductsViewModel>>(products);

            return new PagedResponse<IEnumerable<GetAllProductsViewModel>>(productViewModels,parametres.PageNumber,parametres.PageSize);
        }
    }
}

