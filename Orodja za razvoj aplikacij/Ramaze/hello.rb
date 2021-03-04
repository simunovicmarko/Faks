require 'ramaze'
require 'rubygems'

class MyController < Ramaze::Controller
    map '/'
    
    
    
    def index

        # dobi parametre iz requesta {imeAtributa => VrednostAtributa}
        request.params
        # dobi ime iz requesta ki vrne array
        ime = request.subset('ime')
        # ime = ime.map(|args| args.to_s )
        return "Hello, Ramaze!" + ime.to_s
        # return args
    end
    
    # dobi podatke iz URI /Name/param
    def name(param)
        return param
    end 
    
end

Ramaze.start