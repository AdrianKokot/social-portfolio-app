import { PaginationParams } from "./pagination.params";

export interface DiscussionParams extends PaginationParams {
  communityId: string | number;
}
