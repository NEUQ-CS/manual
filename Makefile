.PHONY : all build preview clean

HUGO := hugo
BUILD_OUTPUT := public

all: build

build:
	@$(HUGO) --minify

preview:
	@$(HUGO) server -D

clean:
	@rm -rf $(BUILD_OUTPUT)
	@rm -f .hugo_build.lock
