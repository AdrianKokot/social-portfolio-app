import { PaginationParams } from "./pagination.params";

export interface CommentParams extends PaginationParams {
  discussionId: number | string;
}
