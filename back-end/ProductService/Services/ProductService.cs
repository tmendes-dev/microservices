using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductService.Data;
using ProductService.Models;
using ProductService.Protos;

namespace ProductService.Services
{
    public class ProductService : ProductProtoService.ProductProtoServiceBase
    {
        private readonly ProductsContext _context;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;

        public ProductService(ProductsContext context, ILogger<ProductService> logger, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override Task<Empty> Test(Empty request, ServerCallContext context) => base.Test(request, context);

        public override async Task<ProductModel?> GetProduct(GetProductRequest request, ServerCallContext context)
        {
            try
            {
                Product? product = await _context.Products.FindAsync(request.ProductId);

                if (product is null)
                    throw new ApplicationException($"Product {request.ProductId} not found");

                return _mapper.Map<ProductModel>(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error ocurred in GetProduct method");
                return null;
            }
        }
    }
}
