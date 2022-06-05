DROP TABLE IF EXISTS order_details;
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS customers;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS shippers;
DROP TABLE IF EXISTS suppliers;
DROP TABLE IF EXISTS product_categories;
DROP TABLE IF EXISTS employees;
DROP TABLE IF EXISTS regions;


CREATE TABLE IF NOT EXISTS public.product_categories
(
    product_category_id smallint NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 32767 CACHE 1 ),
    product_category_name character varying(15) COLLATE pg_catalog."default" NOT NULL,
    product_category_description text COLLATE pg_catalog."default",
    product_category_picture bytea,
    CONSTRAINT "PK_product_categories" PRIMARY KEY (product_category_id)
);

CREATE TABLE IF NOT EXISTS public.regions
(
    region_id smallint NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 32767 CACHE 1 ),
    region_description bpchar COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT regions_pkey PRIMARY KEY (region_id)
);

CREATE TABLE IF NOT EXISTS public.suppliers
(
    supplier_id smallint NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 32767 CACHE 1 ),
    supplier_name character varying(40) COLLATE pg_catalog."default" NOT NULL,
    supplier_contact_name character varying(30) COLLATE pg_catalog."default",
    supplier_contact_title character varying(30) COLLATE pg_catalog."default",
    supplier_address character varying(60) COLLATE pg_catalog."default",
    supplier_city character varying(15) COLLATE pg_catalog."default",
    region_id smallint,
    supplier_postal_code character varying(10) COLLATE pg_catalog."default",
    supplier_country character varying(15) COLLATE pg_catalog."default",
    supplier_phone character varying(24) COLLATE pg_catalog."default",
    supplier_fax character varying(24) COLLATE pg_catalog."default",
    supplier_homepage text COLLATE pg_catalog."default",
    CONSTRAINT suppliers_pkey PRIMARY KEY (supplier_id),
    CONSTRAINT fk_suppliers_regions FOREIGN KEY (region_id)
        REFERENCES public.regions (region_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE IF NOT EXISTS public.products
(
    product_id smallint NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 32767 CACHE 1 ),
    product_name character varying(40) COLLATE pg_catalog."default" NOT NULL,
    supplier_id smallint,
    product_category_id smallint,
    product_quantity_per_unit character varying(20) COLLATE pg_catalog."default",
    product_unit_price real,
    product_units_in_stock smallint,
    product_units_on_order smallint,
    product_reorder_level smallint,
    product_discontinued integer NOT NULL,
    CONSTRAINT products_pkey PRIMARY KEY (product_id),
    CONSTRAINT fk_products_product_categories FOREIGN KEY (product_category_id)
        REFERENCES public.product_categories (product_category_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE RESTRICT,
    CONSTRAINT fk_products_suppliers FOREIGN KEY (supplier_id)
        REFERENCES public.suppliers (supplier_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE IF NOT EXISTS public.shippers
(
    shipper_id smallint NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 32767 CACHE 1 ),
    shipper_name character varying(40) COLLATE pg_catalog."default" NOT NULL,
    shipper_phone character varying(24) COLLATE pg_catalog."default",
    CONSTRAINT shippers_pkey PRIMARY KEY (shipper_id)
);

CREATE TABLE IF NOT EXISTS public.customers
(
    customer_id character varying(128) COLLATE pg_catalog."default" NOT NULL,
    customer_name character varying(40) COLLATE pg_catalog."default" NOT NULL,
    customer_contact_name character varying(30) COLLATE pg_catalog."default",
    customer_contact_title character varying(30) COLLATE pg_catalog."default",
    customer_address character varying(60) COLLATE pg_catalog."default",
    customer_city character varying(15) COLLATE pg_catalog."default",
    region_id smallint,
    customer_postal_code character varying(10) COLLATE pg_catalog."default",
    customer_country character varying(15) COLLATE pg_catalog."default",
    customer_phone character varying(24) COLLATE pg_catalog."default",
    customer_fax character varying(24) COLLATE pg_catalog."default",
    CONSTRAINT pk_customers PRIMARY KEY (customer_id),
    CONSTRAINT fk_customers_regions FOREIGN KEY (region_id)
        REFERENCES public.regions (region_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE IF NOT EXISTS public.employees
(
    employee_id character varying(128) COLLATE pg_catalog."default" NOT NULL,
	employee_email character varying(256) COLLATE pg_catalog."default" NOT NULL,
    employee_last_name character varying(20) COLLATE pg_catalog."default" NOT NULL,
    employee_first_name character varying(10) COLLATE pg_catalog."default" NOT NULL,
    employee_title character varying(30) COLLATE pg_catalog."default",
    employee_title_of_courtesy character varying(25) COLLATE pg_catalog."default",
    employee_birth_date date,
    employee_hire_date date,
    employee_address character varying(60) COLLATE pg_catalog."default",
    employee_city character varying(15) COLLATE pg_catalog."default",
    region_id smallint,
    employee_postal_code character varying(10) COLLATE pg_catalog."default",
    employee_country character varying(15) COLLATE pg_catalog."default",
    employee_home_phone character varying(24) COLLATE pg_catalog."default",
    employee_extension character varying(4) COLLATE pg_catalog."default",
    employee_photo bytea,
    employee_notes text COLLATE pg_catalog."default",
    employee_supervisor_id character varying(128) COLLATE pg_catalog."default",
    employee_photo_path character varying(255) COLLATE pg_catalog."default",
    CONSTRAINT employees_pkey PRIMARY KEY (employee_id),
    CONSTRAINT fk_employees_employees FOREIGN KEY (employee_supervisor_id)
        REFERENCES public.employees (employee_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_employees_regions FOREIGN KEY (region_id)
        REFERENCES public.regions (region_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
	CONSTRAINT employee_email_unique UNIQUE (employee_email)
);

CREATE TABLE IF NOT EXISTS public.orders
(
    order_id smallint NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 32767 CACHE 1 ),
    customer_id character varying(128) COLLATE pg_catalog."default" NOT NULL,
    employee_id character varying(128) COLLATE pg_catalog."default" NOT NULL,
    order_date date,
    order_required_date date,
    order_shipped_date date,
    shipper_id smallint,
    order_freight real,
    order_ship_name character varying(40) COLLATE pg_catalog."default",
    order_ship_address character varying(60) COLLATE pg_catalog."default",
    order_ship_city character varying(15) COLLATE pg_catalog."default",
    order_ship_region_id smallint,
    order_ship_postal_code character varying(10) COLLATE pg_catalog."default",
    order_ship_country character varying(15) COLLATE pg_catalog."default",
    CONSTRAINT orders_pkey PRIMARY KEY (order_id),
    CONSTRAINT fk_orders_customers FOREIGN KEY (customer_id)
        REFERENCES public.customers (customer_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_orders_employees FOREIGN KEY (employee_id)
        REFERENCES public.employees (employee_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_orders_regions FOREIGN KEY (order_ship_region_id)
        REFERENCES public.regions (region_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_orders_shippers FOREIGN KEY (shipper_id)
        REFERENCES public.shippers (shipper_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);


CREATE TABLE IF NOT EXISTS public.order_details
(
    order_detail_id smallint NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 32767 CACHE 1 ),
    order_id smallint NOT NULL,
    product_id smallint NOT NULL,
    order_unit_price real NOT NULL,
    order_quantity smallint NOT NULL,
    order_discount real NOT NULL,
    CONSTRAINT order_details_pkey PRIMARY KEY (order_detail_id),
    CONSTRAINT fk_order_details_orders FOREIGN KEY (order_id)
        REFERENCES public.orders (order_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_order_details_products FOREIGN KEY (product_id)
        REFERENCES public.products (product_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);
