CREATE TABLE public."item"
(
    id SERIAL PRIMARY KEY,
	title text,
    description text
);
CREATE TABLE public."section"
(
    id SERIAL PRIMARY KEY,
	title text,
    description text,
	item_id integer NOT NULL,
    CONSTRAINT course_item_id_fkey FOREIGN KEY (item_id)
        REFERENCES public."item" ("id") MATCH SIMPLE
        ON DELETE CASCADE 
);
CREATE TABLE public."course"
(
    id SERIAL PRIMARY KEY,
    title text,
    description text,
    section_id integer NOT NULL,
    CONSTRAINT course_item_id_fkey FOREIGN KEY (section_id)
        REFERENCES public."section" ("id") MATCH SIMPLE
        ON DELETE CASCADE 
);