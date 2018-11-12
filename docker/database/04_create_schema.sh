#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname birdsightings <<-EOSQL

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;

CREATE TABLE species (
    id SERIAL,
    name VARCHAR NOT NULL,
    total INTEGER NOT NULL DEFAULT 0,
    PRIMARY KEY (name),
    UNIQUE (id)
);

CREATE TABLE sightings (
    seen TIMESTAMP(0) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    species INTEGER NOT NULL,
    PRIMARY KEY (seen, species),
    FOREIGN KEY (species) REFERENCES species(id) 
);

CREATE FUNCTION sightings_insert()
  RETURNS trigger AS
\$\$
BEGIN
    UPDATE species
    SET total = total + 1
    WHERE NEW.species = species.id;
    RETURN NEW;
END;
\$\$
LANGUAGE 'plpgsql';

CREATE TRIGGER update_total
AFTER INSERT ON sightings
FOR EACH ROW EXECUTE PROCEDURE sightings_insert();

INSERT INTO species (name) VALUES ('varis');
INSERT INTO species (name) VALUES ('harakka');

GRANT USAGE ON SCHEMA public TO birdsightings;
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO birdsightings;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO birdsightings;
GRANT EXECUTE ON ALL FUNCTIONS IN SCHEMA public TO birdsightings;

EOSQL
