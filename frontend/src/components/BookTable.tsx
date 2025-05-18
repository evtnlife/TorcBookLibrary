import React from "react";
import {Table, TableBody, TableCell, TableHead, TableRow, IconButton, Paper, Box} from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import type {Book} from "../types/Book";

type Props = {
	books: Book[];
	onEdit: (book: Book) => void;
	onDelete: (book: Book) => void;
};

export const BookTable: React.FC<Props> = ({books, onEdit, onDelete}) => (
	<Paper sx={{p: 2}}>
		<Box sx={{overflowX: "auto"}}>
			<Table sx={{minWidth: 650}}>
				<TableHead>
					<TableRow>
						<TableCell>Title</TableCell>
						<TableCell>Author</TableCell>
						<TableCell>ISBN</TableCell>
						<TableCell>Category</TableCell>
						<TableCell>Copies</TableCell>
						<TableCell>Actions</TableCell>
					</TableRow>
				</TableHead>
				<TableBody>
					{books.map((book) => (
						<TableRow key={book.id}>
							<TableCell>{book.title}</TableCell>
							<TableCell>
								{book.firstName} {book.lastName}
							</TableCell>
							<TableCell>{book.isbn}</TableCell>
							<TableCell>{book.category}</TableCell>
							<TableCell>
								{book.copiesInUse}/{book.totalCopies}
							</TableCell>
							<TableCell>
								<IconButton onClick={() => onDelete(book)}>
									<DeleteIcon />
								</IconButton>
								<IconButton onClick={() => onEdit(book)}>
									<EditIcon />
								</IconButton>
							</TableCell>
						</TableRow>
					))}
				</TableBody>
			</Table>
		</Box>
	</Paper>
);
