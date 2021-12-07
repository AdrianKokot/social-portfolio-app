export interface Discussion {
  id: number;
  title: string;
  authorName?: string;
  authorId: string;
  votesUp: number;
  votesDown: number;
  content: number;
  createdAt: Date;
  editedAt?: Date;
}
