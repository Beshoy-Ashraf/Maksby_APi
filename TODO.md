# TODO: Fix EF Core Foreign Key Configuration

## Issue:
EF Core doesn't support `.HasForeignKey(f => f.Product.Id)` - it requires direct property access

## Files to Edit:
1. Data/Models/batch/Batch.cs - Add ProductId foreign key property
2. Data/Models/Income/ClientInvoiceProduct.cs - Add ProductId and ClientInvoiceId foreign key properties
3. Data/Config/BatchConfiguration/ConfigurationForBatch.cs - Update to use ProductId
4. Data/Config/IncomeConfiguration/ConfigurationForClientInvoicesProduct.cs - Update to use ProductId and ClientInvoiceId

## Steps Completed:
- [x] Identified the problematic configuration files
- [x] Read model files to understand structure
- [ ] Add foreign key properties to Batch model
- [ ] Add foreign key properties to ClientInvoiceProduct model
- [ ] Update Batch configuration
- [ ] Update ClientInvoiceProduct configuration
- [ ] Test database operations

