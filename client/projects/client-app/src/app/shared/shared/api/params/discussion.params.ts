import { PaginationParams } from "./pagination.params";

export interface DiscussionParams extends PaginationParams {
  community: string | number;
}
