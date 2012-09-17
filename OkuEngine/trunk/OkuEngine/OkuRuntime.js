// Actor class
function Actor(actorId) {
  this.actorId = actorId;

  this.getX = function() {
    return oku_getActorX(this.actorId);
  }

  this.getY = function() {
    return oku_getActorY(this.actorId);
  }

  this.setX = function(x) {
    oku_setActorX(this.actorId, x);
  }

  this.setY = function(y) {
    oku_setActorY(this.actorId, y);
  }

  this.getAngle = function() {
    return oku_getActorAngle(this.actorId);
  }

  this.setAngle = function(angle) {
    oku_setActorAngle(this.actorId, angle);
  }
  
}