import React from "react";
import {Button, TextField, Stack, Paper} from "@mui/material";
import type {BookSearchDto} from "../types/BookSearchDto";

type Props = {
	search: BookSearchDto;
	setSearch: (dto: BookSearchDto) => void;
	onSearch: () => void;
};

export const BookSearch: React.FC<Props> = ({search, setSearch, onSearch}) => (
	<Paper sx={{p: 2}}>
		<Stack spacing={2} direction={{xs: "column", sm: "row"}}>
			<TextField
				label="Author"
				value={search.author || ""}
				onChange={(e) => setSearch({...search, author: e.target.value})}
			/>
			<TextField
				label="ISBN"
				value={search.isbn || ""}
				onChange={(e) => setSearch({...search, isbn: e.target.value})}
			/>
			<TextField
				label="Category"
				value={search.category || ""}
				onChange={(e) => setSearch({...search, category: e.target.value})}
			/>
			<Button variant="contained" onClick={onSearch}>
				Search
			</Button>
		</Stack>
	</Paper>
);
