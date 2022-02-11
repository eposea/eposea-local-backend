CREATE DATABASE eposea
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
CREATE TABLE IF NOT EXISTS public."Course"
(
    "Id" integer NOT NULL DEFAULT nextval('course_id_seq'::regclass),
    "Title" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "Description" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "Item_id" integer NOT NULL,
    CONSTRAINT course_pkey PRIMARY KEY ("Id"),
    CONSTRAINT course_item_id_fkey FOREIGN KEY ("Item_id")
        REFERENCES public."Item" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Course"
    OWNER to postgres;

    -- Table: public.Item

-- DROP TABLE IF EXISTS public."Item";

CREATE TABLE IF NOT EXISTS public."Item"
(
    "Id" integer NOT NULL DEFAULT nextval('item_id_seq'::regclass),
    CONSTRAINT item_pkey PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Item"
    OWNER to postgres;