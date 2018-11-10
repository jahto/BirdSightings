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
$$
BEGIN
    UPDATE species
    SET total = total + 1
    WHERE NEW.species = species.id;
    RETURN NEW;
END;
$$
LANGUAGE 'plpgsql';

CREATE TRIGGER update_total
AFTER INSERT ON sightings
FOR EACH ROW EXECUTE PROCEDURE sightings_insert();

INSERT INTO species (name) VALUES ('varis');
INSERT INTO species (name) VALUES ('harakka');
