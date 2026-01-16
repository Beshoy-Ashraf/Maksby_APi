# TODO - Fix ChangeStatus Endpoint

## Steps to Complete:
1. [x] Add `ChangeBatchStatus` method to `IBatchServices` interface
2. [x] Implement `ChangeBatchStatus` in `BatchServices` class
3. [x] Fix `ChangeStatus` endpoint in `EditBatchController`

## Summary of Changes:
- Added `ChangeBatchStatus` method to interface
- Implemented the method in BatchServices to update only the status field
- Fixed the ChangeStatus endpoint to properly call the new service method with `[FromBody]` for status selection


