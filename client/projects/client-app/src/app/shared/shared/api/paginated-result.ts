export interface PaginatedResult<T> {
  items: T[];
  pageNumber: number;
  totalPages: number;
  totalCount: number;
  count: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
}
