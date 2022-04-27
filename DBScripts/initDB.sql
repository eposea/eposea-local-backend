CREATE TABLE public."item"
(
    id SERIAL PRIMARY KEY,
	title text,
    description text,
	section_id integer NOT NULL,
    CONSTRAINT section_id_fkey FOREIGN KEY (section_id)
        REFERENCES public."section" ("id") MATCH SIMPLE
        ON DELETE CASCADE 
);
CREATE TABLE public."section"
(
    id SERIAL PRIMARY KEY,
	title text,
    description text,
	course_id integer NOT NULL,
    CONSTRAINT course_id_fkey FOREIGN KEY (course_id)
        REFERENCES public."course" ("id") MATCH SIMPLE
        ON DELETE CASCADE 
);
CREATE TABLE public."course"
(
    id SERIAL PRIMARY KEY,
    title text,
    description text
);