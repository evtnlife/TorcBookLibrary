import React, {useEffect, useState} from "react";
import {Button, Stack, TextField, Paper} from "@mui/material";
import type {Book} from "../types/Book";

type Props = {
	book?: Book;
	onSubmit: (book: Book) => void;
	onCancel: () => void;
};

export const BookForm: React.FC<Props> = ({book, onSubmit, onCancel}) => {
	const [form, setForm] = useState<Book>({
		id: 0,
		title: "",
		firstName: "",
		lastName: "",
		totalCopies: 0,
		copiesInUse: 0,
		type: "",
		isbn: "",
		category: "",
	});

	useEffect(() => {
		if (book) setForm(book);
	}, [book]);

	return (
		<Paper sx={{p: 2}}>
			<Stack spacing={2}>
				<TextField
					label="Title"
					value={form.title}
					onChange={(e) => setForm({...form, title: e.target.value})}
					fullWidth
				/>
				<TextField
					label="First Name"
					value={form.firstName}
					onChange={(e) => setForm({...form, firstName: e.target.value})}
					fullWidth
				/>
				<TextField
					label="Last Name"
					value={form.lastName}
					onChange={(e) => setForm({...form, lastName: e.target.value})}
					fullWidth
				/>
				<TextField
					label="Total Copies"
					type="number"
					value={form.totalCopies}
					onChange={(e) => setForm({...form, totalCopies: +e.target.value})}
					fullWidth
				/>
				<TextField
					label="Copies In Use"
					type="number"
					value={form.copiesInUse}
					onChange={(e) => setForm({...form, copiesInUse: +e.target.value})}
					fullWidth
				/>
				<TextField
					label="Type"
					value={form.type}
					onChange={(e) => setForm({...form, type: e.target.value})}
					fullWidth
				/>
				<TextField
					label="ISBN"
					value={form.isbn}
					onChange={(e) => setForm({...form, isbn: e.target.value})}
					fullWidth
				/>
				<TextField
					label="Category"
					value={form.category}
					onChange={(e) => setForm({...form, category: e.target.value})}
					fullWidth
				/>
				<Stack direction="row" spacing={2}>
					<Button variant="contained" onClick={() => onSubmit(form)}>
						Submit
					</Button>
					<Button variant="outlined" onClick={onCancel}>
						Cancel
					</Button>
				</Stack>
			</Stack>
		</Paper>
	);
};
